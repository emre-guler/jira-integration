# Jira Integration Project

This project provides a microservices-based integration with Jira, built using .NET. It enables seamless interaction with Jira's functionality through a set of specialized microservices.

## Architecture

The project follows a microservices architecture with the following components:

- **API Gateway** (Port: 9000): Acts as the main entry point for all client requests, handling routing and request aggregation
- **User API** (Port: 9001): Manages user-related operations and authentication

## Prerequisites

- Docker and Docker Compose
- .NET SDK (latest version)
- A Jira account with API access

## Getting Started

1. Clone the repository:
```bash
git clone [repository-url]
cd jira-integration
```

2. Build and run the services using Docker Compose:
```bash
docker-compose up --build
```

## Service URLs

- API Gateway: http://localhost:9000
- User API: http://localhost:9001

## Project Structure

```
jira-integration/
├── JiraIntegration.sln        # Solution file
├── docker-compose.yml         # Docker compose configuration
├── dockerfile-ms-apigateway   # Dockerfile for API Gateway
├── dockerfile-ms-userapi      # Dockerfile for User API
└── ServiceUrls.txt           # Service endpoint configurations
```

## Development

To run the services locally for development:

1. Ensure all prerequisites are installed
2. Start the services using Docker Compose
3. Access the API Gateway at http://localhost:9000

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Requestx
