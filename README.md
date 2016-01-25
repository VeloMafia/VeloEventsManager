# VeloEventsManager
Teamwork project for Telerik Academy

### Site pages

- **Statistics**
    - **Home** - Statistics about created events, total galleries etc.
    - **Calendar** - Calendar with events (could be custom user control).

- **Events**
    - **My events** - Displays all events for the current user
    - **All events** - Displays all available events for the current user. Admins can edit them.
    - **Add event** - Create new event. Only admins.
    - **Event Details** - Detail information for the event.
    	GEORGI

- **Users**
    - **All Users** - Lists all users details. Admins can edit them.
        TODOR
        
- **Profile** - Current user profile. Can be edited.
    TODOR

## Requirements

### Database

- User
    - username
    - pass
    - firstName
    - lastName
    - mobile
    - skills (mechanic, medic, orientation)
    - languages (enumeration - English, Spanish etc.)
    - roles (enumeration - admin, regular)
    - bike
    - equipment (enumeration - spare tyre 26", 15mm spanner for cranks etc.)
    - enduranceIndex (calculated from previous trips statistcs)
    - events
    - avatar

- Bike
    - weight
    - height
    - width
    - length

- Event
    - name
	- description
    - start date
    - end date
    - eventDays
    - users
    - total distance
	- price

- EventDay
    - date
	- description
    - start time and point
    - end time and point
    - route
    - users
    - routes (could be more than one options - easy option, expert option)
    - proposed routes (proposed by users, when event is in progress)
    - photos

- Route
    - points
    - length (calculated from points)
    - ascent (calculated from points)
    - descent (calculated from points)
    - expected duration
    - difficulty (calculated from length and ascent)

- Point (get them from google maps via google maps API ?)
    - name
    - lattitude
    - longitude
    - elevation

- Photo
    - name
    - date
    - location (url, saved on local disk or saved in db)

### Site map (Navigator)
- Home
- Calendar
- Events
    - All events
    - My events (private)
    - Add event (admin)
- Users (private)
- Profile (private)

### Functionality

- Admins
    - have all the rights of regular users
    - create, edit, delete and view all events
    - add events routes
	- can approve/deny users to events
    - can add values to enumerations - example new language, new equipment or skill item

- Regular Users
    - can add proposal routes to events
    - can create, edit, delete and view all their routes
	- can make a request to join in the event
    - add proposal routes to events
    - view all events they are part of and all public
    - view all users for event
    - view event route (graph)
    - view event days
    - view event day details

- Public users
    - can view all public events
