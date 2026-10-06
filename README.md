# Sistema Digital de Votación Estudiantil (SDVE)

Miniproyecto de escritorio en C# Windows Forms con .NET 10 para Windows.

Permite seleccionar una, dos o tres convocatorias: Sociedad de Alumnos, Consejo Universitario y Consejo de Representantes. Incluye candidatos oficiales y no registrados, conteo por centro/carrera/grupo, participación y abstencionismo, gráficas y exportación CSV, JSON y XML.

Los alumnos acceden únicamente con un ID del padrón predefinido. Los votos se confirman al finalizar las papeletas, se guardan en CSV y permanecen separados del registro de participación. No se guarda ID del alumno junto con el candidato elegido.

## Ejecutar

1. Instala el SDK .NET 10 en Windows y utiliza Visual Studio con soporte para ese SDK y desarrollo de escritorio .NET.
2. Abre `SDVE.slnx` y ejecuta el proyecto `SDVE` con F5.
3. Prueba un ID pendiente, como `123459`, `123463` o `123467`. Selecciona las convocatorias con sus botones y pulsa **Enviar** para completar las papeletas y confirmar.
4. Para consultar directamente el reporte, entra como administrador con la clave de demostración `123456`.

Los datos incluidos son ficticios: 72 alumnos, 54 participantes por elección y 18 abstenciones. Los valores cambian conforme se realizan pruebas. Los CSV fuente están en `SDVE/Datos`; las copias que utiliza la aplicación están en `Datos` junto al ejecutable.

## Compilar y probar

Desde la carpeta de la solución:

```powershell
dotnet build .\SDVE\SDVE.csproj
dotnet run --project .\tests\SDVE.Padron.Tests\SDVE.Padron.Tests.csproj
```

Las pruebas trabajan con copias de los CSV en su propia salida y comprueban padrón, filtros, conteo, anonimato, selección de convocatorias, cancelación, persistencia, duplicados y recuperación de archivos.

Consulta [las instrucciones completas](SDVE/README.md) para configurar catálogos, utilizar filtros y conocer el guardado de datos.

## Archivos del repositorio

Incluye la solución, proyectos, código C#, archivos del diseñador, recursos `.resx`, pruebas y CSV ficticios. `.gitignore` excluye compilaciones, preferencias locales de Visual Studio, respaldos de simulación y archivos temporales de recuperación. Los recursos `.resx` y los archivos `.Designer.cs` forman parte de la aplicación.
