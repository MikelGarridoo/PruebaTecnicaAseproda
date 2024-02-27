# Pista de Surtidores

Este proyecto es una implementación de una pista de surtidores en forma de librería en C#, que proporciona métodos para controlar y gestionar los surtidores en una estación de servicio.

## Descripción

La pista de surtidores permite gestionar el estado de los surtidores, incluyendo la liberación, prefijado y bloqueo de los mismos, así como el registro de los suministros realizados en cada surtidor.

## Requisitos del Sistema

- .NET Core 3.1
- Visual Studio (Se ha desarrollado en Visual Studio 2022)

## Instalación

1. Clona o descarga el repositorio de GitHub.
2. Abre el proyecto en Visual Studio.
3. Compila la solución para generar el ensamblado.

## Decisiones de diseño

- Clases y Estructuras: Se utilizan clases y estructuras para modelar los elementos principales del sistema, como la clase PistaSurtidores, que representa la pista en sí misma, y la clase Surtidor, que modela cada surtidor individualmente. Además, se tiene la estructura Suministro, que encapsula la información de cada suministro realizado.

- Validación de Entrada: Se realizan validaciones de entrada en los métodos que reciben parámetros, como PrefijarSurtidor, LiberarSurtidor y BloquearSurtidor, para garantizar que los valores proporcionados sean válidos según los requisitos del enunciado.

- Uso de Excepciones: Se lanzan excepciones específicas, como ArgumentException, con mensajes de error personalizados cuando se detectan condiciones de error durante la ejecución de los métodos.
