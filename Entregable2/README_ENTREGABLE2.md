# Entregable 2 — Instalación del Sistema Digital de Votación Estudiantil

## Descripción

El Sistema Digital de Votación Estudiantil (SDVE) es una aplicación de escritorio desarrollada en C# con Windows Forms y .NET 10. Permite emitir votos para Sociedad de Alumnos, Consejo Universitario y Consejo de Representantes, consultar resultados por Centro, Carrera y Grupo, y exportar reportes en CSV, JSON y XML.

Este README corresponde al paquete portable publicado para Windows x64 con .NET incluido. Su instalación consiste en extraer los archivos y ejecutar el programa.

## Requisitos del equipo

- Windows de 64 bits compatible con .NET 10. Se recomienda Windows 11 x64 actualizado.
- Espacio disponible para extraer el paquete y guardar los datos y reportes.
- Permiso de escritura en la carpeta donde se coloque la aplicación.

El paquete autocontenido no requiere instalar Visual Studio, el SDK ni el entorno de ejecución de .NET por separado. Una vez descargado y extraído, el programa funciona con archivos locales y no requiere conexión a Internet para votar o consultar resultados.

## Contenido del paquete

El archivo ZIP debe extraerse completo. Contiene el ejecutable `SDVE.exe`, los archivos de configuración y bibliotecas de la publicación, este README y la carpeta `Datos`.

La carpeta `Datos` contiene:

| Archivo | Contenido |
|---|---|
| `alumnos.csv` | Padrón de alumnos autorizados, con ID, Centro, Carrera y Grupo. |
| `convocatorias.csv` | Convocatorias y su estado activo o inactivo. |
| `candidatos.csv` | Candidatos oficiales de cada convocatoria. |
| `participacion.csv` | Identificación del participante y elección en la que votó, sin candidato elegido. |
| `votos.csv` | Votos necesarios para el conteo, sin ID del alumno. |

Conserve todos los archivos del paquete. La carpeta `Datos` debe permanecer junto a `SDVE.exe`.

## Instalación

1. Descargue el archivo ZIP del programa.
2. Haga clic derecho sobre el ZIP y seleccione **Extraer todo**.
3. Seleccione una ubicación donde pueda guardar archivos, por ejemplo `Documentos\SDVE`.
4. Abra la carpeta extraída y localice `SDVE.exe`.
5. Compruebe que la carpeta `Datos` se encuentra en la misma ubicación que el ejecutable.
6. Abra `SDVE.exe` con doble clic.

Al iniciar, debe aparecer la pantalla de acceso al sistema. Ejecute el programa desde la carpeta extraída, no desde la vista del archivo ZIP.

Puede crear un acceso directo a `SDVE.exe` para facilitar su apertura. El ejecutable debe permanecer con los demás archivos publicados.

## Verificación del funcionamiento

### Acceso como alumno

1. Seleccione la opción **Alumno**.
2. Escriba un ID existente en el padrón.
3. Pulse **Ingresar**.
4. Seleccione las convocatorias en las que desea participar. Los botones seleccionados se muestran en azul; otro clic los deselecciona.
5. Pulse **Enviar** y complete las papeletas seleccionadas.
6. Elija un candidato oficial o escriba un candidato no registrado.
7. Guarde las selecciones y acepte la confirmación final para emitir los votos.

Después del aviso de éxito, el sistema vuelve al inicio de sesión. Los alumnos y docentes no tienen acceso a los reportes ni a las exportaciones; esas funciones son exclusivas del administrador.

El sistema obtiene automáticamente el Centro, Carrera y Grupo del alumno. No permite registrar alumnos desde el acceso. Un ID desconocido se rechaza y cada alumno puede participar una sola vez por elección.

Los IDs `123459`, `123463` y `123467` tienen elecciones pendientes en los datos iniciales de demostración. Su disponibilidad cambia si ya se han utilizado para confirmar votos.

### Consulta de resultados

1. Seleccione la opción **Administrador**.
2. Introduzca la clave de demostración `123456`.
3. Pulse **Ingresar**.
4. Seleccione la elección que desea consultar.
5. Revise los votos por candidato, la gráfica, la participación y el abstencionismo.
6. Utilice los filtros de Centro, Carrera y Grupo para consultar un segmento. La opción **General** elimina los filtros.
7. Para guardar un reporte, utilice la exportación CSV, JSON o XML y seleccione una carpeta de destino distinta de los archivos internos de `Datos`.

## Datos de demostración

Los datos fuente del proyecto contienen 72 alumnos ficticios, distribuidos entre tres centros, seis carreras y 18 grupos. Inicialmente, cada elección tiene 54 participantes y 18 abstenciones: 75% de participación y 25% de abstencionismo.

Los valores cambian conforme se confirman votos. Los votos y la participación permanecen guardados al cerrar y volver a abrir el programa.

## Respaldo y conservación de datos

Para respaldar la información:

1. Cierre el programa.
2. Copie toda la carpeta `Datos` a una ubicación de respaldo.
3. Identifique la copia con la fecha del respaldo.

Al actualizar la aplicación, conserve los CSV de la instalación utilizada. Sustituirlos por los archivos de demostración reemplazaría la información electoral guardada.

El padrón, la participación y los votos son archivos separados. El registro de participación no incluye el candidato elegido y el archivo de votos no incluye el ID del alumno.

## Solución de problemas

| Problema | Solución |
|---|---|
| El programa no encuentra el padrón. | Compruebe que `Datos\alumnos.csv` está junto al ejecutable y que se extrajo el paquete completo. |
| Faltan bibliotecas o archivos de configuración. | Extraiga nuevamente el ZIP completo; no copie únicamente `SDVE.exe`. |
| No se pueden guardar los votos. | Cierre el programa y coloque la carpeta completa en una ubicación con permiso de escritura, como Documentos. |
| El ID ingresado no está registrado. | Utilice un ID del padrón. El acceso no crea alumnos nuevos. |
| Una convocatoria aparece como ya completada. | El alumno ya participó en esa elección. Puede votar únicamente en las convocatorias pendientes y activas. |
| Los resultados no coinciden con los valores iniciales. | Compruebe si ya se emitieron votos en esa instalación; los datos se conservan entre sesiones. |

## Desinstalación

Cierre SDVE y respalde la carpeta `Datos` si necesita conservar la información. Después elimine la carpeta de la aplicación y los accesos directos que haya creado.

## Referencias

- [Compatibilidad de .NET con Windows — Microsoft](https://learn.microsoft.com/en-us/dotnet/core/install/windows).
- [Publicación autocontenida de aplicaciones .NET — Microsoft](https://learn.microsoft.com/en-us/dotnet/core/deploying/).
- [Repositorio del proyecto SDVE](https://github.com/Slorms/MINI_SDVE).
