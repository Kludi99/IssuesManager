# Issue Management – GitHub and GitLab

An application for managing issues on **GitHub** and **GitLab** platforms.

## Testing on Swagger

To test the application, you must specify the platform number:

- `0` – GitHub  
- `1` – GitLab

The platform number is defined as an **enum**.

You need to also add required configuration in the `appsettings.json` file:

   - For **GitHub**:
     - `Token`: Your GitHub API token
     - `Owner`: Repository owner name
   - For **GitLab**:
     - `Token`: Your GitLab API token

##  Features

- Create new issues
- Edit existing issues
- Close existing issues
