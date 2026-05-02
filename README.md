# File Integrity Checker

Hi! This project explores one of the basics of cybersecurity — **hashing**. 
Hashing is the concept of taking any piece of data (a file, a password, a message)
and turning it into a long, unique string of letters and numbers. 

## Why Hashing Matters for Security

For those who are unfamiliar, in cybersecurity when it comes to the state of
the data, there's a core principle called the **C.I.A. Triad**:

- **C**onfidentiality — data is only accessible to you
- **I**ntegrity — data can't be edited without your knowledge
- **A**vailability — data is available whenever you need it

Hashing helps with **Integrity**. By storing a "baseline" hash of a file and comparing it later, 
you can instantly detect if someone modified that file — even by a single character.
Through this project my goal is to show you how this simply works.

## How things work:

- Scans a folder and creates SHA-256 hashes for every file (`init`)
- Checks individual files against their stored hashes (`check`)
- Lets you update the stored hash after legitimate changes (`update`)

## The Magic Line

The entire concept boils down to one line of C#:

```csharp
byte[] hashBytes = SHA256.HashData(fileBytes);
```
That's pretty much it! The project is not perfect - it explores a very complex topic in a really simple way, but 
regardless it's just meant to be a reference for how things work. I hope this was helpful to anybody interested
in this topic :).
