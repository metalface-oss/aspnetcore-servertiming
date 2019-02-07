# FAQ

## Why recorder's methods are called BeginRecord and EndRecord?
Naming was chosen to be visually similar to [Asynchronous Programming Model (APM)](https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/asynchronous-programming-model-apm) and while it shares nothing more in common, such naming convention may be familiar to many .NET developers. Calling these methods will not change identation of your existing code (unlike using ```using``` statements) and diffs will be small.
  
## Do I need to pass a metric name to EndRecord?
Usually, you don't. The last started recording is ended if the metric name is not provided.

## May I use the same metric name multiple times?
Yes, if previous recording is ended. Server-Timing Working Draft allows duplicate metric names:
> A response MAY have multiple server-timing-metric entries with the same metric-name, and the user agent MUST process and expose all such entries.

## May I record a custom metric if I already know duration?
Yes, by calling ```Record(name, duration, description)``` method.
