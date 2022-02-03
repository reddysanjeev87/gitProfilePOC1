# Git Hub Users Repository

This document describes the **project assignment** for the **Git Hub Users Repository** in ASP.NET MVC (.NET 6.0).

## How to use

1. Enter username in input box and press submit button.
2. In case of username exists, 
	* On left side: You will get user profile picture, name and location information.
	* On right side: You will get user repositories info like repository name, description and stargazer count.
3. In case of username does not exists,
	* You will get error message "Search result not found." error message.
4. In case of user dont have any repository,
	* You will get "**user name** doesn't have any public repositories yet." error message.
5. In case of git api quota limit exceeded,
	* You will get "Request rate limit exceeded." error message.
6. In any other case like something went wrong,
	* You will get "Something went wrong, please try again later." error message.
7. In case of exception occurs,
	* You will get redirected to application error page.

## Functional Requirements

Create an ASP.Net MVC (.Net Framework only) website with the following:
* a page containing a text box to enter a Username and a Submit button to Search GitHub for a user by their username.
* Have the back-end call the GitHub Users API (e.g. https://api.github.com/users/robconery) to retrieve the user’s name, location and avatar url from the returned Json. 
* Use the repos_url value to get a list of all the repos for the user. 
* Do not use any other third party tool for managing api connection.
* On the results page, please show the username, location, avatar image and the 5 repos with the highest stargazer_count. 
* For each of the repos show the Name (provide a link to the repo from this field), Description and Stargazers.
* Ensure you consider invalid input. Also consider what happens if the user cannot be found or if they don’t have any repositories.
