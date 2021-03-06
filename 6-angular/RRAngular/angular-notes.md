# Angular

Front end fw used to create SPAs (Single Page Application). Modularized in nature, front end design revolves around the idea of components making up a page.

## SPAs

Single Page Applications as you've guessed are web apps that are contained in a single page. It means that, when you access that webapp for the first time, you are served a page from the server, and any other interaction with that page, JS takes care of and manipulates the page via the DOM. You have the illusion of ineracting with different pages, but it's really the same page being rewritten over and over again.

### Advantages of SPAs

1. No server roundtrips!
   - I don't have to go to a serve to get a new HTML page!
2. Your page will always be responsive and it doesn't freeze up as a whole.
3. Super easy to deploy in prod and even to version over time.
4. (They are good for the skin and relaxation)

### Disadvantages of SPAs

1. Overhead of setting up and the learning curve.
2. With Angular, the startup load time of your SPA takes a while. This is because when you query the server for the first time, you are given everything.
3. Getting external libraries to play with Angular is a little difficult.

## Architecture

### Modules

Kinda like a namespace... Kinda like a project, kinda like a csproj file. Containers for a cohesive block of code dedicated to an app domain, a workflow, or a closely related set of capabilities. In a nutshell: it is a way to encapsulate code/logic that go together. Modules in angular are based on modules in es6, but they have metadata. The `@NgModule` metadata plays an important role in guiding the Angular compilation process that converts the app code you write into highly performant JS code. [Read more about it](https://angular.io/guide/ngmodule-vs-jsmodule). To declare a module, you use the @NgModule decorator.

### Components

Views with logic. When scaffolding a component, the ng cli gives you 4 files:

1. css file (styling)
2. html file (template)
3. ts file (logic)
4. spec.ts file (unit testing)

In actuality, a component only needs 2 files:

1. html file
2. ts file

But if you really wanna trim the fat:

1. just ts file, write the template inline

How do you define a class as a component? You use the @component decorator.

#### Templates

This just the html file. This defines the structure of your component. What does it look like? How do you arrange the data?

### Services

Logic that is shared between components or other services. Components would have logic that is specific to the view, any logic that is shared or not related to the view, you store in services. Sort of like you BL if your components are views. Services have the @Injectable decorator that allows them to be injected as deps in components or other services.

Dep Injection is built in with Angular (yay).

### Decorators

Flags for the compiler. When the compiler sees them it does something with the info.
Used to distinguish the functionality of your classes, functions, fields.

[List of decorators in Angular](https://medium.com/@madhavmahesh/list-of-all-decorators-available-in-angular-71bdf4ad6976)

## Working with Angular

### Promises vs Observables

Both of them represent async operations that result in some form of return. Promises are closed after the result has been returned. Once it is fulfilled its done. Observables are still open just in case, additional results can be returned.

### Life Cycle hooks

1. ngOnInit()
   - called upon component initialization
2. ngOnChanges(changes: SimpleChanges)
   - called when something changes on the component
3. etc
   - go research the rest

### Data Binding in Angular

1. Interpolation
   - This is from ts to template
   - You get the data and present it to the template
   - {{property}}
2. Property Binding
   - [property name here]
3. Event Binding
   - (event name here)
4. Two Way
   - This is from ts to template and vv
   - Data that you set on the template is also being change in the logic
   - [()]

### Directives

- used to alter your template

1. Structural
   - used to alter the structure, i.e., dom manipulate the template to dynamically create elements as needed
   - *ngFor, *ngIf, \*ngSwitch
2. Attribute
3. Custom

### Routing

#### Module:

Routing Module, needs to be imported in the app module

#### Where do I set up my routes?

app-routing.module.ts, in this file, there exists a const array of routes called routes, in that array the paths are declared using key value pairs to declare paths and the components that they show. You can also declare other characteristics of that path, such as auth guards.

#### Working with routes

Using the <router-outlet> tag as a placeholder for the views you want to present depending on the routes.

#### Navigate between routes? (How do I navigate between components?)

1. routerLink = "path that I set in my app-routing.module.ts
2. directly accessing the path/component via the url
3. using a router object, you navigate via the router.navigate(['path here'], extra stuff here like query params) method

### Sharing data between components

We need to be able to pass data between components, how do we accomplish this?

1. Use query params
2. Decorators
   1. @Input decorator, you can pass info from parent component to child component, so you can set the value of child fields in the parent component
   2. @Output decorator, for passing info from child to parent
3. Some form of subscription, you would have a service with an observable that contains data that you share amongst components, this is what the auth service utilizes in auth 0 to check whether a person is logged in or not

### Pipes

Pipes are used to transform data, like strings, currency amounts, etc, for display. Pipes can do other things, like the async pipe, that forces an Observable/Promise to execute and takes the result. To apply a pipe, you use the | operator. You can also create custom pipes for data transformation.

- Some useful pipes:
  - aynsc pipe (to execute observables and promises to get their values)
  - json pipe (to check the model/representation that you're receiving.)

### Filters

A way for you to select data you care about. The exists a filter method that allows you to filter out data, from a list (not angular specific, it's actually JS). Filters have a read only access to your data.
