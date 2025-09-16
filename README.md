# localizable-enum-description
A means of hydrating an ItemsControl's items with enum values that are decorated with attributes that map to culture-selected string values.

This is the barebones example of the LocalizedBoundEnum pattern that uses the decoration as its means of providing globalized/localized enum bindings to ItemsSource controls. The usual methods of binding the selected values are not shown here, but are supported as they always are; to demonstrate them here is out of scope.
The core purpose is to provide a simple and effective way to bind localized enum values to UI controls in a XAML-based application without requiring code-behind, custom data providers, or cluttering up your ViewModels.
In doing so, it promotes separation of concerns by making both the XAML and the view model/code behind cleaner and more maintainable.

Considerations:
- This pattern has been workable in some form since the early days of WPF.
- It is not a new pattern, but it is a useful one.
- This takes the basic concept of a BoundEnum and extends it not only beyond the regular DescriptionAttribute, but also in support of localization/globalization.
- This pattern is not limited to WPF and can be used in other XAML-based frameworks like UWP, MAUI, Avalonia, etc.
- It advances the BoundEnum beyond the old methods by no longer relying on the ObjectDataProvider, which isn't available in Avalonia.
- One improvement consideration is to implement a caching mechanism to avoid repeated reflection calls for the same enum type.
- Other improvements could be to support more complex localization scenarios, like:
  - Context-based translations or pluralization,
  - Integration with localization frameworks like ResX or gettext.
  - Providing default values, the unselected value, or a "Please select" option.
  - Supporting enums with flags (bitwise combinations).
  - Multiple resource files spread across several projects (i.e., shared libraries).
  - Provide a way to refresh the localized values if the application's culture changes at runtime.
  - Extend the pattern to support other types of collections, not just enums.
  - Provide a way to customize the display format of the enum values, such as adding prefixes or suffixes.
  - Finally, another improvement could be to provide a way to filter the enum values based on certain criteria, such as user roles or permissions.

This can go off in many directions, but the core concept is to provide a simple and effective way to bind localized enum values to UI controls in a XAML-based application and provide the framework for more complex "bolt-on" solutions that would otherwise unnecessarily clutter up your code-behind or view model.
