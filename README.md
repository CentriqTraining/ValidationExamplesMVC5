# ValidationExamplesMVC5
Validation Scenarios Visual Studio 2017 (Updated 9/2017)
This solution contains 2 projects illustrating a couple of the many different ways you can do data validation using MVC

##The first one is ValidationExamples

This one uses the IDataErrorInfo interface to enable server side validation.  It is very modular and allows for easy changing your validation rules on the fly.

One drawback, however is that client side validation is not automatically included.  If you want client side validation, you need to include it yourself.

##The second one is ValidationExamples2
This one uses a Nuget Package called FluentValidation which takes care of all of your validation needs.  Still somewhat modular, but a huge advantage is that in most cases, your client side validation is included.
