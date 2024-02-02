# Tafs.Orchestrator.API.Abstractions

This package contains a complete set of type and API abstractions for the Orchestrator API. It provides no complete implementations; rather, it acts as a general, library-agnotic standard definition of the UiPath Orchestrator's API.

These types serve as the foundation of Tafs.Orchestrator's entire API surface, but can just as easily be used to implement your own Orchestrator library, independently of Tafs.Orchestrator.

The primary goal of this project is to model Orchestrator's API as closely as possible, while at the same time applying appropriate C# practices and builtin types (such as `DateTimeOffset`).

## Structure

The library is divided into type categories, organized to match Orchestrator's API documentation as closely as is realistic. Each object defined by UiPath has a corresponding interface, with inline documentation that matches UiPath's.

The REST API surface is is similarly divided by purpose, wherein related endpoints are grouped together (licensing, logs, assets, queues, etc.).

## Usage

No particular usage recommendations exist for this library.