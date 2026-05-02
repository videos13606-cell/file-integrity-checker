# File Integrity Checker

Hello, everyone! This project is a simple tool I built while 
learning about cybersecurity fundamentals - hashing.
Hashing is the concept of taking any piece of data (a file, a password, a message)
and turning it into a long, unique string of letters and numbers. Through this project
i try to show you a really simple example of how these things work.
This project was created with the help of AI tools.
This project is also taken from this website:
https://roadmap.sh/projects/file-integrity-checker

## Why is HASHING important? What's the point of it?

For those who are unfamiliar, in cybersecurity when it comes to the state of
the data, there's a core principle called the **C.I.A. Triad**:

- **C**onfidentiality — data is only accessible to you
- **I**ntegrity — data can't be edited without your knowledge
- **A**vailability — data is available whenever you need it

Hashing helps with **Integrity**. By storing a hash of a file and comparing it later, 
you can instantly detect if someone modified the file (and you will see yourself 
when you are testing the project).

## How things work:

- Scans a folder and creates SHA-256 hashes for every file (`init`)
- Checks individual files against their stored hashes (`check`)
- Lets you update the stored hash after legitimate changes (`update`)

## Try It Yourself!

1. Run the program and type init to create baseline hashes
2. Open testfile.txt and change anything, save it
3. Type check testfile.txt - you'll see it detects the change
4. Type update testfile.txt to store the new hash

## The Magic Line

The entire concept boils down to one line of C#:

```csharp
byte[] hashBytes = SHA256.HashData(fileBytes);
```
That's pretty much it! The project is not perfect - it explores a very complex topic in a really
simple way, but regardless it's just meant to be a reference for how things work. :).
