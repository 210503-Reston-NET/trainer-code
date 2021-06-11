# Authorization vs Authentication

- Authentication - who you are
  - you establish who you are
  - cookies
  - jwt tokens - encoded identification
    - 3 parts: header, payload/data, signature
    - Header: algorithm (what's used to hash your stuff), type of token: jwt
    - Payload/data: who you are, identifies you, user id, name, etc
    - Signature: header(encoded).payload(encoded).aSecret
    - Ex: `eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c`
  - IDaaS
    - Identification as a service
    - Ex: Auth0, Okta, 0Auth, etc
    - You register with these services and they store the client credentials for you
    - Secret to be able to unhash the tokens from the client
- Authorization - what you can do
  - RBAC
  - Role based access control, very common
  - Assign roles to users, in ASP.NET you can assign actions to be permissible via certain roles using attributes
