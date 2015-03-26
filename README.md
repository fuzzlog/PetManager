# PetManager


1. Crated new Table (AnimalStatus for better Convention over Configuration)
	a. Added columns to table
		i. AnimalStatusId
		ii. StatusName
2. Added new column to Animals table (AnimalStatusId  for better Convention over Configuration)
	a. It's the foreign key for table AnimalStatus
	b. Populated table with data plus a new Status
		i. 1. Deployed
		ii 2. Training
		ii 3. On Leave
		iv. 4. Ready To Deploy
		v. 5. Decesased
		vi. 6. Just Arrived
3. Transfered pertinent data from animal_status table's status column to Animal table''s AnimalStatusID column

The modifications to the database are saved as scripts int he "sql" folder of this client project.


Regarding the task requested.

Instead of returning just a JSON-based list of Animals, I'm returning instead a JSON-based response object that whose "Message" property 
contains the JSON-based list of animals (when appropriate).  It also has "Status" property whose values are ither "OK" or "Error".
The "Message" property will contain a pertinent value depending on the status of propoerty.

	The Start project is a client that calls the API as requesed in the task list.

	   -- The first endpoint will accept any number of pet ids as a parameter and return each animals  data in a JSON results array.
			- Implemented via SQL over Context to lessen the potential bottleneck created by the "OR" statements that will be created by 
			  entity framework because of the way it handles "IN" clauses
       -- The 2nd endpoint will accept any number of status' and return all animals that are applicable.
			- Implemented via SQL over Context to lessen the potential bottleneck created by the "OR" statements that will be created by 
			  entity framework because of the way it handles "IN" clauses
       -- The third endpoint will allow for creation of a new record.
			- Implemented via normal context usage.
