- There is one drawback in home controller. If you take a look at the whole application let's say we have 20 actions 
  methods inside the home controller and only one action method needed all of these IOptions settings.
  It would be a waste to inject it in the constructor because if it is calling the action method that is not using this,
  why would we even inject that and create an object, so it would be better if we can inject all four of this directly 
 inside the action method which needs those services.
  