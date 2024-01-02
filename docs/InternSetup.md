# Baltimore Life Intern Dev Setup


## Sections

* After IT Onboarding

* Git Bash Download (Optional)

* Node.js Download

* Visual Studio and Starting localhost

* Visual Studio Code (Optional)

* Running localhost

* Extra Resources


## After IT Onboarding

Sign in to the remote desktop and open your browser of choice.

I recommend bookmarking: 

* Outlook Email
* Teams
* Jira
* Azure DevOps
* Production and UAT URL of assigned project

You can find your account creds for each item above in your email after you sign in. If not, contact Jeff or your manager.


## Git Bash Download (Optional)

This step is for anyone who is used to using a bash terminal to execute their Git commands. Visit https://git-scm.com/download/win to download Git Bash to the remote desktop. You may need admin permission, and in that case, contact Dan from IT or ask someone to connect you with him.


## Node.js Download

Visit https://nodejs.org/en/download and click on the Windows installer under the LTS (Long Term Support) on your remote desktop. You may need admin permission, and in that case, contact Dan from IT or ask someone to connect you with him. 

> Run `node -v` in your terminal to check if node has been installed.


## Visual Studio and Starting localhost

Visual Studio should be already installed, but you should check if all the nesecary packages are installed. Search and open Visual Studio Installer &rarr; Click modify on Visual Studio Professional &rarr; Confirm ASP.NET and Web Development, Azure Development, Node.js Development, and Data Storage and Processing are all selected. If not, you may need admin permission, and in that case, contact Dan from IT or ask someone to connect you with him.

After confirming all necessary packages are installed, open Visual Studio Professional (I recommend pinning to desktop taskbar), and begin the process of pulling the repositories from Baltimore Life's Azure DevOps. 

Select Clone A Repository &rarr; Select Azure DevOps under Browse a repository &rarr; Sign in with your baltimore life email &rarr; Type in or select `baltlife.visualstudio.com` &rarr; Select and clone the repos necessary for your project (Agent portal is `AgentPortal_Site` and `ExternalHubCore_Service`). 

After the repository has been cloned, select the repo when you open Visual Studio. If it doesn't show, select 'Open a local folder'. The default file path for where the repo lives is at `C:\Users\{name}\Source\Repos`. 

After opening the repo, select the `{repo_name}.sln` file (I recommend pinning that `.sln` file next time you open Visual Studio) and hit the `IIS Express` button to run the local host environment. A browser window that is loading the localhost should pop up.

Before you start editing any code, switch to your appropriate branch. Click on the button to the left of the repo's name (should be labeled main or master) &rarr; Select Remotes and click on your branch, or create a new branch named after your tasks.

> (Optional) Here's how to make git bash the default terminal in Visual Studio. Select the PowerShell terminal tab near the bottom &rarr; Click the gear icon &rarr; Click Add and select the new option &rarr; Name it `Bash`, make the shell location this file path `C:\Users\{name}\AppData\Local\Programs\Git\bin\bash.exe`, and empty the arguements field (No arguements are nessecary) &rarr; Hit apply and set as default. After closing the terminal tab and opening another terminal in Visual Studio, you should see your bash terminal. Run your git commands and check out to your appropriate branch.


## Visual Studio Code (Optional)

Visual Studio Code should be already installed, and I personally edit my code on VS Code while Visual Studio is running the localhost. Turn on hot reload on Visual Studio while the project is running by clicking on the fire/red icon near the top and turn on Auto Save on Visual Studio Code by selecting File at the top left and making sure Auto Save has a checkmark next to it. Do the rest of your customization as you please.


## Extra Resources

Don't be afraid to ask your manager or colleagues questions or for help!