# Change Log
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

## [1.1.0]
### Added
- Lacking XML documentation comments

### Changed
- Removal of `IMessageWriter` in favor of `IMessagesStream` and `IMessagesStreamObserver`
- Adjustment for `DefaultLogger` to use both `IMessagesStream` and `IMessagesStreamObserver`
- Minor name refactoring

## [1.0.1]
### Changed
- New NuGet deployment

## [1.0.0]
### Added
- Initial project files