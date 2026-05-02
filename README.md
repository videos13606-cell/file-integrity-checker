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

## Try it yourself (Step-by-Step Guide)

If you want to see how the program works in practice, here is a quick experiment you can do yourself:

**Step 1:** Open your terminal (I used Command Prompt) in the project folder.

**Step 2:** Let's create a simple text file to experiment with. Let's name it `test.txt` and write "Hello" inside it. 
*(This is our important "log" file that we want to protect).*

**Step 3:** Let the program scan it and save its original hash (its unique cryptographic signature). Type:
> `./integrity-check init test.txt`

The program just calculated the SHA-256 hash of the file and saved it in a secure location. Now it knows what the original looks like!

**Step 4:** Let's check if everything is okay. Type:
> `./integrity-check check test.txt`
**Expected result:** Status: Unmodified

Makes sense! Nobody touched the file, so the hash matches the one we saved in Step 3

**Step 5: Time to "hack" the file!** 
Open `test.txt` (for example, with Notepad), add just one extra letter or space, and save it.

**Step 6:** Let's run the check again to see if the program notices the difference. Type:
> `./integrity-check check test.txt`
**Expected result:** Status: Modified (Hash mismatch)

See that? The status changed! Even one added letter changes the entire cryptographic hash of the file. This is exactly the goal of the program - to alert us immediately if someone touched or changed our files without permission!)

**Step 7:** If we want to tell the program the change was intentional, we just update the hash:
> `./integrity-check update test.txt`

## The Magic Line

The entire concept boils down to one line of C#:

```csharp
byte[] hashBytes = SHA256.HashData(fileBytes);
```
That's pretty much it! The project is not perfect - it explores a very complex topic in a really
simple way, but regardless it's just meant to be a reference for how things work. :).
