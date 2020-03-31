@author=Jared McCannon
@title=My First Blog Service
@end
# Setting Up a Blog Service

How to start a technical blog? That was the question I started with. After listening to 
tons of podcasts, reading other blogs, and dreaming...I was thought why not just
start one about creating one.  So...here we go:

## Project New

## Where to Store?
Let's start out with a simple directory store. Fun fact 
when storing files locally, they'll show up in the same
directory as the `.dll` files. Which is not how it appears
in the project directory. This makes sense if you understand
where the dotnet project builds to, but something that might
I didn't think about right away when making the repository.
 
## Unit Testing
The unit tests run in the same directory as the rest of the 
project. However, you don't want to be testing the live 
posts. So we'll create a directory with test posts in there
so we'll always be able to test. We'll denote this by
prepending `TEST` to each file.

## Building the First Test
First let's build the file parsing since that's the main mechanism for 
returning our blog posts.  We'll want to get the metadata out of each file. 
For the time being, that will be stored on the top of the file.

## Get Recent Posts