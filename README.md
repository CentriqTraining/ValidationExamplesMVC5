# ValidationExamplesMVC5
Validation Scenarios Visual Studio 2017 (Updated 9/2017)
This solution contains 2 projects illustrating a couple of the many different ways you can do data validation using MVC

## AttributeValidation
This examples uses the Validation Attributes found in the *System.ComponentModel.DataAnnotations* namespace
- Required
- StringLength
- Regex
- Range
- Custom

## AttributeValidationShell
This is the same as the above demo, but without any attributes added.  If you are following the video that goes with this demonstration, you can open this empty demo and follow along the with the demo.

## RemoteValidation
This example also uses Attribute validation, but makes use of a little known Attribute (Not in the Microsoft official Curriculum) called **Remote**

## IDataErrorInfoValidation
This example uses the IDataErrorInfo interface to enable server side validation.  It is very modular and allows for easy changing your validation rules on the fly.

## FluentValidation
This example uses a Nuget Package called FluentValidation which takes care of all of your validation needs.  Still somewhat modular, but a huge advantage is that in most cases, your client side validation is included.
