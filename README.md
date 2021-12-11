# WeatherProject
Hi,

 

There are two possible work in front of data:

 

Run the script in the SQL folder to create a db , and change the connectionString in an Appsetings.json file.
Work with moc data -
In the Startup file inside the C # folder,

Put in note the : Services.Addtransient <Ifavorecitiesservice, Favorecitiesservice> ();

And the comment from comment the Services.Addtransient <ifvorecitiesservice, mocfavorecitiesservice> ();

Do not forget to do npm i.
Thanks.

