# 1_Proyecto-de-UES
CONSIGNA PARA EL PROYECTO DE DESARROLLO
Universidad de El Salvador
Facultad de Ingeniería y Arquitectura
Escuela de Ingeniería de Sistemas Informáticos
Fundamentos de Programació
1. Indicaciones Generales
Objetivo: Desarrollar una solución aplicando conceptos básicos de la unidad 4 a la 9: "Desarrollo de una solución con un lenguaje de programación".
Ponderación: 7%.
Grupos: Máximo 3 estudiantes.
Lenguaje y Entorno: C# consola, utilizando el IDE Visual Studio Code (instalar C# Dev Kit).
Metodología: Resolver la "Clave" asignada según el número de grupo, aplicando lo aprendido y cumpliendo con la rúbrica.

2. Requerimientos del Sistema (Lógica de Negocio)
El sistema debe gestionar citas médicas con las siguientes reglas:
Especialidades Disponibles:
01: Medicina General
02: Pediatría
03: Cardiología
04: Dermatología
05: Oftalmología
06: Ortopedia
07: Ginecología
Datos de la Cita: Nombre del paciente, edad, nombre del médico, fecha (DD/MM/AAAA), costo (mayor a $0), estado (Atendida, Cancelada, Pendiente) y forma de pago (Efectivo, Tarjeta, Seguro médico).
Reglas de Descuento y Cobro:
Paciente > 60 años → 10% de descuento.
Pago con Seguro médico → 15% de descuento.
Cita cancelada → No genera cobro.
Condiciones Especiales: La "Calificación de atención" (escala 1-5) solo aplica si el estado es "Atendida" (A).
Almacenamiento: La información debe ser almacenada en arreglos (unidimensionales o multidimensionales).
Estructura: Se deben usar al menos tres funciones o métodos.

3. Menú Principal
El programa debe mostrar las siguientes opciones:
Registrar cita.
Mostrar reportes.
Buscar cita
Mostrar tercera cita registrada.

Salir.
4. Reportes y Consultas
El sistema debe generar los siguientes informes:
Listado general de todas las citas registradas, ordenado por fecha.
Listado por especialidad, mostrando las citas de cada área médica.
Reporte financiero: Total recaudado por forma de pago (descontando citas canceladas).
Reporte de desempeño médico: Promedio de calificación por médico (solo citas atendidas).
Búsqueda de citas por: nombre del paciente, código de especialidad o estado de la cita.

5. Validaciones Obligatorias
No permitir campos vacíos.
Validar formato del código (C-000X).
Validar códigos de especialidad (01-07) y forma de pago (1-3).
Validar estados (A, C, P) y calificación (1-5 cuando aplique).
Evitar duplicidad de códigos.
Edad y costo deben ser mayores a 0.

6. Formato de Entrega
Se debe entregar una carpeta comprimida en ZIP llamada Clave#_GrupoDeTrabajo (Ej: Clave1_Grupo1) que contenga:
Código Fuente: Proyecto de C#.
Documento PDF: Con el mismo nombre de la carpeta, incluyendo:
Portada (Universidad, Facultad, Escuela, Materia, Docente, integrantes por apellido en orden alfabético, fecha y año).
Índice, Introducción y Objetivos.
Desarrollo de la solución (ver consigna y rúbrica).
Conclusiones, Referencias bibliográficas y Anexos.