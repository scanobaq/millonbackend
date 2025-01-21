#Millonbackend

## Backend para la aplicación Millon

## Arquitectura del Proyecto

El proyecto Millonbackend está implementado utilizando una arquitectura basada en capas y patrones de diseño comunes en aplicaciones modernas. A continuación, se describen los componentes principales y los patrones utilizados:

### Capas del Proyecto

1. **API**: Esta capa contiene los controladores que exponen los endpoints de la API. Utiliza ASP.NET Core para manejar las solicitudes HTTP y devolver respuestas. Los controladores se encuentran en la carpeta `src/Api/Controllers`.

2. **Aplicación**: Esta capa contiene la lógica de negocio de la aplicación. Aquí se encuentran los comandos y consultas (CQRS) que manejan las operaciones de creación, lectura, actualización y eliminación (CRUD). También se incluyen los DTOs (Data Transfer Objects) y los manejadores de comandos y consultas. Esta capa se encuentra en la carpeta `src/Application`.

3. **Infraestructura**: Esta capa contiene la implementación de los repositorios y la configuración de la base de datos. Utiliza MongoDB como base de datos y se encarga de la persistencia de los datos. Los repositorios se encuentran en la carpeta `src/Infrastructure/Persistence/Repositories`.
4. **Dominio**: Esta capa contiene las entidades y las reglas de negocio. Las entidades se encuentran en la carpeta `src/Domain/Entities`.


### Patrones de Diseño

1. **CQRS (Command Query Responsibility Segregation)**: Este patrón se utiliza para separar las operaciones de lectura (queries) de las operaciones de escritura (commands). Los comandos y consultas se manejan mediante el uso de MediatR, un librería que facilita la implementación de este patrón.

2. **Repository Pattern**: Este patrón se utiliza para abstraer la lógica de acceso a datos y proporcionar una interfaz limpia para interactuar con la base de datos. Los repositorios se encargan de realizar las operaciones CRUD y de aplicar filtros y paginación.

3. **Dependency Injection**: ASP.NET Core proporciona un contenedor de inyección de dependencias que se utiliza para inyectar las dependencias necesarias en los controladores, manejadores y repositorios. Esto facilita la prueba y el mantenimiento del código.

4. **Middleware**: Se utiliza middleware personalizado para manejar errores y excepciones de manera centralizada. Esto permite capturar y registrar errores de manera consistente en toda la aplicación.

### Tecnologías Utilizadas

- **ASP.NET Core**: Framework para construir aplicaciones web y APIs.
- **MediatR**: Librería para implementar el patrón CQRS.
- **MongoDB**: Base de datos NoSQL utilizada para almacenar los datos. la base de datos se crea en memoria cuando ejecutas dotnet run o dotnet watch. se creo un archivo seed que creara datos para pruebas.
- **AutoMapper**: Librería para mapear objetos entre diferentes capas de la aplicación.

### Ejemplo de Flujo de Trabajo

1. Un cliente realiza una solicitud HTTP a un endpoint de la API.
2. El controlador correspondiente recibe la solicitud y crea un comando o consulta.
3. El comando o consulta se envía a través de MediatR al manejador correspondiente.
4. El manejador interactúa con el repositorio para realizar la operación solicitada.
5. El resultado se devuelve al controlador, que a su vez lo envía de vuelta al cliente como respuesta HTTP.

Esta arquitectura y los patrones utilizados permiten construir una aplicación escalable, mantenible y fácil de probar.

