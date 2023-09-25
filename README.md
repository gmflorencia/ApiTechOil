# ApiTechOil C#
El proyecto está desarrollado con Net Core 6
​
## **Especificación de la Arquitectura**
​
### **Capa Controller**
Será el punto de entrada a la API. En los controladores deberíamos definir la menor cantidad de lógica posible y utilizarlos como un pasamanos con la capa de servicios.
​
### **Capa DataAccess**
Es donde definiremos el DbContext y crearemos los seeds correspondientes para organizar nuestras entidades.
​
### **Capa Entities**
En este nivel de la arquitectura definiremos todas las entidades de la base de datos.
​
### **Capa Repositories**
*En esta capa definiremos las clases correspondientes para realizar el repositorio genérico y la unidad de trabajo.
*	Tambien se definiran las Interfaces que utilizaremos en los servicios.
​
### **Capa Helper**
*	En este nivel vamos a definir la lógica que pueda ser de utilidad para todo el proyecto. Por ejemplo, el método para encriptar contraseñas.

  ### **Capa Services**
  Se incluirán todos los servicios solicitados por el proyecto, en este caso utilizamos el patron Unit of Work con el objetivo de administrar operaciones con la base de datos.

   ### **Capa Infraestructure**
   En esta capa se van a gestionar los errores Http para proporcionar una respuesta adecuada.
   

  
  
​
