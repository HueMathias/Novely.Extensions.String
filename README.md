# Novely.Extensions.Strings

Extensions pratiques pour la manipulation et la validation des chaînes de caractères (`string`) en .NET, avec support pour la culture et des validations courantes comme e-mail, téléphone, URL et codes postaux.

## Sommaire

- [Fonctionnalités principales](#fonctionnalités-principales)
- [Installation](#installation)

---

## Fonctionnalités principales

- Validation et manipulation de chaînes de caractères :
  - `IsEmail()` → Vérifie si une chaîne est un e-mail valide
  - `IsPhoneNumber(CultureInfo)` → Vérifie si une chaîne est un numéro de téléphone valide selon la culture
  - `IsUrl()` → Vérifie si une chaîne est une URL valide
  - `IsPostalCode(CultureInfo)` → Vérifie les codes postaux selon la culture (FR, US, CA par défaut)
	- Support de **plusieurs cultures** pour les validations (FR, US, CA)
	- Possibilité de **s’étendre facilement** avec des patterns personnalisés (`RegisterPostalCodePattern`)
  - `FirstCharToUpper()` → Met la première lettre d’une chaîne en majuscule


---

## Installation

Depuis NuGet :

```bash
dotnet add package YourCompany.Extensions.Strings
```

Ou via le Package Manager : 
```bash
Install-Package YourCompany.Extensions.Strings
```


