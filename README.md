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

## 🛠️ How to try it yourself (Beginner-friendly Guide)

Never used GitHub or a command terminal before? No problem! Here is a simple, step-by-step guide to test my program on your own computer.

**Step 1: Get the code**
Go to the top of this page, click the green **"<> Code"** button, and select **"Download ZIP"**. Extract (unzip) the downloaded folder somewhere easy to find, like your Desktop. Open the extracted folder.

**Step 2: Open the Command Terminal**
Click on the address bar at the top of the folder window (where it says the folder path), delete the text, type `cmd`, and press **Enter**. A black screen (the terminal) will pop up. You are now ready!

*(Note: Make sure you have the .NET SDK installed on your computer to run C# code).*

**Step 3: Create a "secret" file**
Let's create a file to protect. In the black terminal, type this exactly and press Enter:
> `echo "Hello" > secret.txt`
*(Result: You just created a text file named 'secret.txt' in the folder. This is the file we want to protect from hackers).*

**Step 4: Lock it in (Save the fingerprint)**
Now, let's tell the program to remember exactly how this file looks. Type:
> `dotnet run -- init secret.txt`
*(Result: The program successfully saves a mathematical "fingerprint" of your file. If even a single byte changes later, the fingerprint won't match).*

**Step 5: Check if everything is safe**
Let's make sure our file is untouched. Type:
> `dotnet run -- check secret.txt`
*(Result: You will see **Status: Unmodified**. This means nobody has messed with your file).*

**Step 6: Play the Hacker!**
Let's simulate an attack. Open the `secret.txt` file normally with Notepad, add an extra space or change "Hello" to "Hello!", and save it. 

**Step 7: Catch the change**
Run the check command one more time in the terminal:
> `dotnet run -- check secret.txt`
*(Result: You will see **Status: Modified (Hash mismatch)**. The program instantly caught the unauthorized change because the new fingerprint doesn't match the original one!)*

## The Magic Line

The entire concept boils down to one line of C#:

```csharp
byte[] hashBytes = SHA256.HashData(fileBytes);
```
That's pretty much it! The project is not perfect - it explores a very complex topic in a really
simple way, but regardless it's just meant to be a reference for how things work. :).
