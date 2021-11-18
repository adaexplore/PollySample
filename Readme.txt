Requirement: 
You have IBORepository that performs CRUD operations for some business object. 
Task is to create the BOService class for this business object with a single method that calls the Save method of IBORepository
and retries the Save at most 3 times in case of ConnectionException.  
