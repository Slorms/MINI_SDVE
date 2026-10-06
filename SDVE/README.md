# Sistema Digital de Votación Estudiantil (SDVE)

Aplicación C# Windows Forms para Windows con .NET 10. Abre `SDVE.slnx` en Visual Studio y ejecuta el proyecto SDVE con F5.

## Prueba rápida

1. Entra como **Alumno** con el ID `123459` (también están pendientes `123463` y `123467`).
2. Haz clic en el botón **Sociedad de Alumnos**: queda azul y muestra **Seleccionada**. También puedes seleccionar dos o las tres convocatorias. Otro clic deselecciona el botón y descarta su papeleta pendiente.
3. Pulsa **Enviar**. Se abren únicamente las papeletas seleccionadas, una por una. Elige un candidato oficial o escribe uno no registrado y pulsa **Guardar selección** en cada papeleta.
4. Acepta la confirmación final. Se guardan únicamente las convocatorias seleccionadas, aparece un aviso de éxito y vuelves al login. El reporte y las exportaciones son exclusivos del administrador. Ningún voto se registra si una papeleta está incompleta o cancelas la confirmación.
5. Entra como administrador para comprobar los resultados. En Sociedad de Alumnos verás 55 participantes de 72, aproximadamente 76.4% de participación y 23.6% de abstencionismo. Las otras dos elecciones conservan 54 participantes y 75% de participación.
6. Cierra el reporte y vuelve a ingresar como alumno con `123459`. Sociedad de Alumnos muestra **Ya participaste**; aún puedes votar en las otras dos elecciones.
7. Cierra y vuelve a ejecutar: los resultados confirmados se conservan en CSV.
8. Para probar cancelación, entra con `123463`, selecciona dos convocatorias y pulsa **Enviar**. Completa la primera papeleta y cancela la segunda. Regresas a Form1 con las selecciones pendientes; pulsa **Cancelar** y acepta descartar. No cambian los votos ni la participación.

Los valores anteriores corresponden a los datos iniciales, antes de otras pruebas. `123456` y `123457` ya votaron en las tres convocatorias. `999999` no existe y debe rechazarse. El administrador abre el reporte directamente con la clave `123456`.

## Padrón predefinido y anonimato

El alumno escribe únicamente su ID. El sistema busca en `Datos/alumnos.csv` y carga centro, carrera y grupo en la sesión; nunca solicita esos datos al alumno, modifica el padrón ni crea alumnos desconocidos.

El padrón contiene 72 alumnos ficticios de los centros y carreras del proyecto: tres centros, dos carreras por centro y tres grupos por carrera con cuatro alumnos por grupo. El CSV usa UTF-8 y el esquema `Id,Centro,Carrera,Grupo`; admite la columna opcional `Semestre` del formato anterior. Se validan encabezados, datos obligatorios e IDs únicos y numéricos de hasta seis dígitos. Los campos CSV admiten comas y comillas escapadas, pero no saltos de línea.

Los archivos se mantienen separados:

- `Datos/alumnos.csv`: quién puede votar y su centro/carrera/grupo. Solo se consulta.
- `Datos/participacion.csv`: `Rol,Id,Eleccion`. Evita votar dos veces en cada elección y permite calcular participación y abstencionismo con el padrón del segmento. No contiene candidatos.
- `Datos/votos.csv`: `Eleccion,Centro,Carrera,Grupo,Candidato,Registrado`. Contiene únicamente votos confirmados. No guarda ID, marcas de tiempo ni identificadores compartidos con participación. Las filas se mezclan al confirmar para no conservar el orden de llegada.
- `Datos/convocatorias.csv`: `Eleccion,Activa`. `True` habilita una de las tres convocatorias y `False` la desactiva para votar; sus resultados históricos siguen disponibles.
- `Datos/candidatos.csv`: `Eleccion,Candidato`. Lista oficial cargada al abrir la papeleta y el reporte. Cambia este catálogo antes de iniciar las pruebas, sin modificar el código. Se conserva la opción de candidato no registrado.

Si el nombre escrito coincide con un candidato oficial, se cuenta como registrado. Los nombres de candidatos se comparan sin distinguir mayúsculas y minúsculas.

El antiguo `votantes.csv` deja de controlar el acceso y no se actualiza al votar. Si una instalación anterior tiene ese archivo y todavía no existe `participacion.csv`, se convierte su lista en participaciones para las tres elecciones del flujo antiguo. No se importan registros de `%LOCALAPPDATA%` en el nuevo flujo. La copia antigua permanece disponible.

## Confirmación y persistencia

Los tres botones de Form1 funcionan como selectores independientes, sin CheckBoxes. Conservan el color azul y la marca de selección mientras completas las papeletas. Las convocatorias inactivas o ya completadas aparecen deshabilitadas. Los controles están definidos en Form1.Designer.cs; el constructor no crea controles adicionales.

**Enviar** se habilita al seleccionar al menos una convocatoria y abre sus papeletas pendientes. Cancelar una papeleta vuelve a Form1 sin guardar votos, conservando las otras selecciones pendientes para continuar o descartarlas. El sistema exige exactamente una papeleta por convocatoria y vuelve a validar padrón y participaciones al aceptar la confirmación final. Cerrar o cancelar Form1 descarta lo pendiente. Las elecciones completadas quedan bloqueadas y el alumno puede regresar para las restantes.

El guardado usa un bloqueo de archivo para impedir confirmaciones simultáneas incompatibles. Votos y participación tienen respaldos temporales separados y un marcador sin datos personales. Si se interrumpe una confirmación antes de terminar, la siguiente lectura restaura ambos archivos al estado anterior. Los errores de escritura permiten reintentar sin sumar nuevamente una papeleta ya confirmada.

Los CSV de ejecución están en `Datos` junto al ejecutable, normalmente `SDVE/bin/Debug/net10.0-windows/Datos`. Los votos y la participación de prueba se copian únicamente si faltan; recompilar conserva los archivos existentes. Los catálogos y el padrón se actualizan desde el proyecto cuando la copia fuente es más reciente. No edites los archivos temporales de recuperación.

## Filtros y exportación

El reporte ofrece Sociedad de Alumnos, Consejo Universitario y Consejo de Representantes. Centro/carrera/grupo se obtienen del padrón. Cada selección actualiza la tabla, gráfica y tarjetas. Cambiar centro limpia carrera y grupo; cambiar carrera limpia grupo. Todos/Todas elimina la restricción correspondiente.

**General** limpia los filtros; **Centro** conserva solo el centro; **Carrera** conserva centro y carrera; **Grupo** conserva los tres campos. **Procesar resultados** recarga los archivos. **Ver participación por grupo** muestra registrados, votantes, abstenciones y porcentajes dentro del segmento seleccionado. La exportación CSV/JSON/XML contiene los resultados filtrados y distingue candidatos registrados de no registrados.

La participación cuenta IDs de alumnos del padrón en `participacion.csv` para la elección seleccionada, no votos pendientes ni alumnos de otros segmentos. El acceso de docente se conserva por compatibilidad; sus votos no se suman a la participación estudiantil.

## Datos iniciales

Se incluyen 54 participantes de 72 alumnos en cada elección y 18 abstenciones: tres participantes y uno pendiente en cada grupo. Hay 162 votos anónimos en total. Las abstenciones se calculan por ausencia de participación en la elección; no se guardan votos vacíos.

Valores iniciales: General = 72 registrados / 54 votantes; Ciencias Básicas = 24 / 18; Sistemas Computacionales = 12 / 9; grupo A = 4 / 3. Todos muestran 75% de participación y 25% de abstencionismo. Las participaciones pueden diferir por elección después de votar solo una o dos convocatorias.

Los respaldos anteriores a la simulación permanecen en `Datos/respaldo_simulacion_*`.

## Compilar y verificar

Desde la carpeta de la solución:

```powershell
dotnet build .\SDVE\SDVE.csproj
dotnet run --project .\tests\SDVE.Padron.Tests\SDVE.Padron.Tests.csproj
```

Las pruebas usan únicamente copias en su carpeta de salida: validación del padrón, sesiones, filtros por centro/carrera/grupo, conteo y porcentajes, combinaciones de una/dos/tres convocatorias, rechazo de papeletas incompletas, cancelación, desmarcado, persistencia, propuestas con comas/comillas, duplicados por elección, revalidación al confirmar, fallos de escritura y recuperación después de una confirmación interrumpida.

La configuración de convocatorias y candidatos se realiza en CSV; no hay pantalla de administración de catálogos ni registro público de alumnos. Las tres convocatorias previstas por la especificación tienen nombres fijos.
