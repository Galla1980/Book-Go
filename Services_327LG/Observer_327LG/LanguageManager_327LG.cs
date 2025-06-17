using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Services_327LG.Observer_327LG
{
    public class LanguageManager_327LG : ISujeto_327LG
    {
        private List<IObserverIdioma_327LG> listaFormularios = new List<IObserverIdioma_327LG>();
        private Dictionary<string, object> traduccion = new Dictionary<string, object>();
        public string Idioma { get; set; }
        public static LanguageManager_327LG Instance { get; } = new LanguageManager_327LG();
        public LanguageManager_327LG()
        {
        }
        public void CambiarIdioma_327LG(string idioma)
        {
            Idioma = idioma;
            NotificarObservadores_327LG();
        }
        public void CargarFormulario_327LG(string formulario)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Languages",$"{Idioma}",$"{formulario}.json");
            if(!File.Exists(path)) throw new FileNotFoundException($"No se encontro el archivo de idioma{path}");
            string json = File.ReadAllText(path);
            traduccion = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
        }

        public string ObtenerString(string clave)
        {
            var claves = clave.Split('.');
            object current = traduccion;
            foreach (var subclave in claves)
            {
                if (subclave.Contains('['))
                {
                    var name = subclave.Substring(0, subclave.IndexOf('['));
                    var indexStr = subclave.Substring(subclave.IndexOf('[') + 1);
                    indexStr = indexStr.TrimEnd(']');
                    int index = int.Parse(indexStr);

                    if (current is Dictionary<string, object> dict && dict.ContainsKey(name))
                    {
                        if (dict[name] is JsonElement element && element.ValueKind == JsonValueKind.Array)
                        {
                            var item = element[index];
                            return item.ToString();
                        }
                    }
                }
                else
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
            }
            return current?.ToString() ?? clave;
        }

        public void AgregarObservador_327LG(IObserverIdioma_327LG observador)
        {
            listaFormularios.Add(observador);
        }
        public void EliminarObservador_327LG(IObserverIdioma_327LG observador)
        {
            listaFormularios.Remove(observador);
        }
        public void NotificarObservadores_327LG()
        {
            foreach (var observer in listaFormularios)
            {
                observer.Actualizar_327LG();
            }
        }

    }  
}
