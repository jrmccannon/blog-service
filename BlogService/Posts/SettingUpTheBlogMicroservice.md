@author=Jared McCannon
@title=My First Blog Service
@end
# Setting Up a Blog Service

How to start a technical blog? That was the question I started with. After listening to 
tons of podcasts, reading other blogs, and dreaming...I was thought why not just
start one about creating one.  So...here we go:

## Project New
Since this will be the backend of the service, we'll just fire up the IDE, I'm using Rider from Jetbrains and create a 
new web api project.  Following the wizard, its pretty straightforward to spin up the new project. The base tech I wanted
to use was .NET Core 3.1 with Docker.

## Where to Store?
Initially, I just want a simple way to store the files. What's simpler than just storing files in the project
directory. I'll be the only one contributing to this service (probably), so I'll just be able to write up the new file
and upload it to the repository.  Later if I'm feeling ambitious, I'll add a database as my next learning project.
 
## Organization
Each file will contain some metadata at the top. I can read the file in, line by line, parsing the data into an object. 
Then, I can return that object to my client application consuming my API.

## Unit Testing
The unit tests run in the same directory as the rest of the 
project. However, you don't want to be testing the live 
posts. So we'll create a directory with test posts in there
so we'll always be able to test. We'll denote this by
prepending `TEST` to each file. Initially we'll make sure we can read a file in and parse out its contents. Then we'll 
move on to more complex querying of the posts.

## Up next
In the next few posts, I'll walk through what we're building and how we're testing it.
Then, I talk through how I set up the hosting service and deploy process.
After that, I'll show how I set up health checks to make sure the API is up and running.