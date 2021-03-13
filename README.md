# TSA Coding Submissions
![baw-badge]

This project is part of a larger solution built for the Technology Student Association (TSA) [High School Coding][tsa-hs-competitions] competition.
The code in the repo provides judges and participants a web interface to interact with problems for the competition.
There are three key components in this repo; a Blazor web application, a SQL database, and web API application.

## Blazor Web Application
This is the UI component for the entire solution and not just for this repo.
The UI provides judges and participants the manage all aspects of the solution such as create/edit problems for the competition, evaluating submissions from participants, and performance of solution as a whole.
The Blazor web application itself has several key aspects.

### Features
- Authentication - *TODO: Add details on authentication*
- Judge Management - *TODO: Add details on judge management*
- Participant Management - *TODO: Add details on participant management*
- Creating Coding Problems - *TODO: Add details on creating coding problems*
- ***TODO: Add details on other key features***

# Documentation
***TODO: Create help/wiki documentation***

# Getting Started
To get started, you need to ensure that several tools are configured and installed locally on your machine.

## Docker
This project is designed and built to run in containers.
As such, external services such as SQL Server and RabbitMQ, are expected to be running and Docker makes the ideal location for this.
Docker Desktop is the quickest way to get up and running, but if you prefer to go with another containerization option you will need the following:

- Docker Engine (or equivalent)
- Docker Compose
- Docker CLI

## .NET Core
The .NET projects in the repo are all targeting .NET Core 3.1 LTS (3.1.11).
For details and to download, please refer to https://dotnet.microsoft.com/download/dotnet-core/3.1.

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Contribute
We welcome anyone that would like to volunteer their time and contribute to this project.
In order to contibute, we do require you to adhere to our [Code of Conduct][cod]. Please take a moment to read over this as it is strictly enforced.

Once you agree to our Code of Conduct, take a look at our [Contributing Guidelines][cg].
This will help explain our coding style, testing practices, and process for integrating your changes into our repo and master branch.

# License
This project is released uner the [MIT License][mit-license].

# Related Projects
[TSA Identity Server][tsa-identity-server] - The identity server that manages logins across all TSA projects

<!-- BADGES -->
[baw-badge]: https://github.com/tj-cappelletti/tsa-coding-submissions/workflows/build-application-workflow/badge.svg "current status"
[baw-master-branch-badge]: https://github.com/tj-cappelletti/tsa-coding-submissions/workflows/build-application-workflow/badge.svg?branch=master "master branch status"
[baw-pull-request-badge]: https://github.com/tj-cappelletti/tsa-coding-submissions/workflows/build-application-workflow/badge.svg?event=pull_request

<!-- REPO LINKS -->
[cg]: CONTRIBUTING.md "Contributing Guidelines"
[cod]: CODE_OF_CONDUCT.md "Code of Conduct"
[mit-license]: LICENSE "MIT License"

<!-- EXTERNAL LINKS -->
[tsa-hs-competitions]: https://tsaweb.org/competitions-programs/tsa/high-school-competitions "TSA High School Competitions"
[tsa-identity-server]: https://github.com/tj-cappelletti/tsa-identity-server "TSA Identity Server"
