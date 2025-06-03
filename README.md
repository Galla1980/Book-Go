# Book&Go - Sistema de Préstamo de Libros

**Book&Go** es un sistema de gestión de préstamos y devoluciones para bibliotecas físicas, desarrollado como trabajo académico final de tercer año del titulo de analista en sistemas. 

## Propósito

El sistema busca digitalizar y optimizar los procesos administrativos de una biblioteca, permitiendo una gestión eficiente de:

- Préstamos
- Devoluciones
- Sanciones
- Reposición de stock

Entre sus objetivos principales se encuentran:

- Facilitar el control de préstamos y devoluciones
- Automatizar la verificación de disponibilidad
- Gestionar sanciones y cobros de señas
- Controlar el stock y generar órdenes de compra automáticamente

## Funcionalidades principales

### RFN1 - Gestión de Préstamos y Devoluciones

- Registro de nuevos clientes
- Consulta y selección de libros disponibles
- Cobro de seña por préstamo (efectivo o tarjeta)
- Registro de devolución, con control de estado del libro
- Aplicación de sanciones en caso de devoluciones tardías o daños

### RFN2 - Gestión de Stock y Reposición

- Visualización de stock por estado:
  - Disponible
  - Prestado
  - Dañado
  - Desaparecido
- Generación automática de órdenes de compra al alcanzar el stock mínimo
- Registro y actualización de datos de proveedores
- Alta de nuevos ejemplares tras la recepción de pedidos

## Roles en el sistema

- **Bibliotecario**
  - Registrar préstamos y devoluciones
  - Registrar sanciones
  - Registrar nuevos clientes
- **Encargado de reposición**
  - Consultar stock
  - Generar órdenes de compra
  - Registrar nuevos ejemplares
- **Repositor**
  - Verificar facturas y órdenes
  - Registrar la llegada de libros
- **Administrador**
  - Crear, modificar, desactivar y desbloquear usuarios
- **Usuario final**
  - Iniciar sesión
  - Cambiar contraseña

## Arquitectura del sistema

- Arquitectura en capas:
  - Presentación
  - Lógica de negocio
  - Acceso a datos
- Persistencia en SQL Server 2022
- Encriptación de contraseñas con SHA-256
