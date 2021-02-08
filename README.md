# emerioschallenge

## Caracteristicas

* Desarrollado como un proyecto de NET CORE 3.1
* Tiene un proyecto NET STANDARD para logica
* Tiene un proyecto NET CORE de consola (Service worker)
* Tiene un proyecto de TEST para mostar uso de Moq, XUnit y FluentAssertions

## Modo de uso

El programa lee un archivo txt de un path que hay que especificar en el archivo appsettings.json de la solucion

```json
{
    "Configuracion":{
        "Path": ""
    }
}
```

* Este archivo debe contener una matriz cuadrada de caracteres alfanumericos.
* Los elementos deben estar separados por comas y un salto de linea al final de cada row.
* Se adjunta el modelo del enunciado.

Para ejecutarlo, abrirlo con un visual studio y ejecutar EMERIOSCHALLENGE.Program.
