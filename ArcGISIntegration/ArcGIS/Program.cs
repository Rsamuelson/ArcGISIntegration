using ArcGIS;

//Note for whoever this may concern:
//   When we were initially testing out the Api Key/Referrer functionality, we were not getting a error code 498 on the invalid referrer call.
//   Afterword, when we opened up a ticket with ESRI and when through the trouble shooting process we found that our called were now being blocked based on the referrer, which is what we initially wanted.
//   From our side, we are considering this issue closed because we cannot reproduce the issue.

var token = "[token]"; //TODO: Set token/Api Key
var validReferrer = "[referrer]"; //TODO: set valid referrer
var invalidReferrer = "abcd1234";

var validAddress = "2309 Euclid Ave, Lower Beaver, Des Moines, 50310";

//Valid Referrer
var expectedValidResult = await new ArcGisService(validReferrer).GetAddressLocationCoordinatesAsync(validAddress, token); 
Console.WriteLine("Valid referrer result:");
Console.WriteLine(expectedValidResult);
Console.WriteLine();

//Invalid Referrer
var expectedInvalidResult = await new ArcGisService(invalidReferrer).GetAddressLocationCoordinatesAsync(validAddress, token);
Console.WriteLine("Invalid referrer result:");
Console.WriteLine(expectedInvalidResult);

