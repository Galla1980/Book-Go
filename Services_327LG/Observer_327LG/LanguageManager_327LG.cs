using System.Text.Json;


namespace Services_327LG.Observer_327LG
{
    public class LanguageManager_327LG : ISujeto_327LG
    {
        private List<IObserverIdioma_327LG> listaFormularios_327LG = new List<IObserverIdioma_327LG>();
        private Dictionary<string, object> traduccion_327LG = new Dictionary<string, object>();
        public string Idioma_327LG { get; set; }
        public static LanguageManager_327LG Instance_327LG { get; } = new LanguageManager_327LG();
        public LanguageManager_327LG()
        {
        }
        public void CambiarIdioma_327LG(string idioma)
        {
            Idioma_327LG = idioma;
            NotificarObservadores_327LG();
        }
        public void CargarFormulario_327LG(string formulario)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Languages", $"{Idioma_327LG}", $"{formulario}.json");
            if (!File.Exists(path)) throw new FileNotFoundException($"No se encontro el archivo de idioma{path}");
            string json = File.ReadAllText(path);
            traduccion_327LG = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
        }

        public string ObtenerString(string clave)
        {
            var claves = clave.Split('.');
            object current = traduccion_327LG;
            foreach (var subclave in claves)
            {
                if (current is Dictionary<string, object> dict && dict.ContainsKey(subclave))
                {
                    current = dict[subclave];
                    if (current is JsonElement el)
                    {
                        if (el.ValueKind == JsonValueKind.Object)
                        {
                            current = JsonSerializer.Deserialize<Dictionary<string, object>>(el.GetRawText());
                        }
                        else
                        {
                            return el.ToString();
                        }
                    }
                }
                else
                {
                    return clave; // clave no encontrada → devuelvo la clave original
                }

            }
            return current?.ToString() ?? clave;
        }

        public void AgregarObservador_327LG(IObserverIdioma_327LG observador)
        {
            listaFormularios_327LG.Add(observador);
        }
        public void EliminarObservador_327LG(IObserverIdioma_327LG observador)
        {
            listaFormularios_327LG.Remove(observador);
        }
        public void NotificarObservadores_327LG()
        {
            foreach (var observer in listaFormularios_327LG)
            {
                observer.Actualizar_327LG();
            }
        }

    }
}
