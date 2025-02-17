# Appariement de formes par squelettisation hiérarchique


## Table des matières
1. [Introduction](#introduction)
2. [Fonctionnalités](#fonctionnalités)
3. [Installation](#installation)
4. [Utilisation](#utilisation)
5. [Structure du projet](#structure-du-projet)
6. [Site Internet](#site-internet)
7. [English Version](#english-version)

## Introduction
Ce projet, basé sur le sujet de thèse de [Leborgne Aurélie](https://perso.liris.cnrs.fr/laure.tougne/theses_doctorants/these_Aurelie_leborgne.pdf), calcule la Distance Euclidienne au Carré (SEDT) et les boules maximales d'une forme. Le programme prend une image BMP en entrée, la transforme en tableau 2D, et effectue divers traitements pour analyser la forme contenue dans l'image.
<div align="center">
    <img src="./Arbre.png" alt="Arbre euclide" width="50%" style="margin-bottom: 20px; border: 1px solid #ccc; border-radius: 8px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
    <img src="./Cheval.png" alt="Cheval euclide" width="50%" style="margin-bottom: 20px; border: 1px solid #ccc; border-radius: 8px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
</div>

## Fonctionnalités
- Transformation d'une image BMP en tableau 2D.
- Calcul de la SEDT.
- Détermination des boules maximales d'une forme.
- Affichage des résultats sous forme de tableau.
- Sauvegarde des images traitées.

## Installation
1. Clonez le dépôt du projet.
2. Assurez-vous d'avoir .NET installé sur votre machine.
3. Ouvrez le projet dans Visual Studio ou tout autre IDE compatible.

## Utilisation
1. Spécifiez le chemin d'accès à votre image BMP dans le fichier `Program.cs`.
2. Exécutez le programme.
3. Les résultats seront affichés dans la console et les images traitées seront sauvegardées.

## Structure du projet
- `SAE12`: Contient le code principal du projet.
- `SAE11` Dossier contenant le site internet explicatif.

## Site Internet
Un site internet a été développé pour expliquer le projet de manière plus détaillée. Vous pouvez accéder au site en ouvrant le fichier `pageAccueil.html` dans le dossier `SAE11/WWWV2`.

# English Version

# Shape Matching by Hierarchical Skeletonization


### Table of Contents
1. [Introduction](#introduction-1)
2. [Features](#features)
3. [Installation](#installation-1)
4. [Usage](#usage)
5. [Project Structure](#project-structure)
6. [Website](#website)

### Introduction
This project, developed by [Leborgne Aurélie](https://perso.liris.cnrs.fr/laure.tougne/theses_doctorants/these_Aurelie_leborgne.pdf), calculates the Squared Euclidean Distance Transform (SEDT) and the maximal balls of a shape. The program takes a BMP image as input, transforms it into a 2D array, and performs various processing to analyze the shape contained in the image.

<div align="center">
    <img src="./Arbre.png" alt="tree euclide" width="50%" style="margin-bottom: 20px; border: 1px solid #ccc; border-radius: 8px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
    <img src="./Cheval.png" alt="horse euclide" width="50%" style="margin-bottom: 20px; border: 1px solid #ccc; border-radius: 8px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
</div>

### Features
- Transformation of a BMP image into a 2D array.
- Calculation of the SEDT.
- Determination of the maximal balls of a shape.
- Display of results in table form.
- Saving of processed images.

### Installation
1. Clone the project repository.
2. Ensure that .NET is installed on your machine.
3. Open the project in Visual Studio or any compatible IDE.

### Usage
1. Specify the path to your BMP image in the `Program.cs` file.
2. Run the program.
3. The results will be displayed in the console, and the processed images will be saved.

### Project Structure
- `SAE12`: Contains the main code of the project.
- `SAE11`: Folder containing the explanatory website.

### Website
A website has been developed to explain the project in more detail. You can access the site by opening the `pageAccueil.html` file in the `SAE11/WWWV2` folder.
