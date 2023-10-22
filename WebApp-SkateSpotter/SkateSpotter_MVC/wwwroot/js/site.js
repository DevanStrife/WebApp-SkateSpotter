// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Define global variables for map, searchManager, infobox, and the current pushpin.
var map, searchManager, infobox, currentPushpin;
// Initialize the map.
function GetMap() {
    map = new Microsoft.Maps.Map('#myMap', {});

    //Add a click event to the map.
    Microsoft.Maps.Events.addHandler(map, 'click', mapClicked);

    //Create an infobox, but hide it. We can reuse it for each pushpin.
    infobox = new Microsoft.Maps.Infobox(map.getCenter(), { visible: false });
    infobox.setMap(map);
}
// Search for locations on the map.
function Search() {
    if (!searchManager) {
        //Create an instance of the search manager and perform the search.
        Microsoft.Maps.loadModule('Microsoft.Maps.Search', function () {
            searchManager = new Microsoft.Maps.Search.SearchManager(map);
            Search()
        });
    } else {
        //Remove any previous results from the map.
        map.entities.clear();

        //Get the users query and geocode it.
        var query = document.getElementById('searchTbx').value;
        geocodeQuery(query);
    }
}
// Geocode a user's query and display results on the map.
function geocodeQuery(query) {
    var searchRequest = {
        where: query,
        callback: function (r) {
            if (r && r.results && r.results.length > 0) {
                var pin, pins = [], locs = [], output = 'Results:<br/>';

                for (var i = 0; i < r.results.length; i++) {
                    //Create a pushpin for each result.
                    pin = new Microsoft.Maps.Pushpin(r.results[i].location, {
                        text: i + ''
                    });
                    pins.push(pin);
                    locs.push(r.results[i].location);

                    output += i + ') ' + r.results[i].name + '<br/>';
                }

                //Add the pins to the map
                map.entities.push(pins);

                //Display list of results
                document.getElementById('output').innerHTML = output;

                //Determine a bounding box to best view the results.
                var bounds;

                if (r.results.length == 1) {
                    bounds = r.results[0].bestView;
                } else {
                    //Use the locations from the results to calculate a bounding box.
                    bounds = Microsoft.Maps.LocationRect.fromLocations(locs);
                }

                map.setView({ bounds: bounds });
            }
        },
        errorCallback: function (e) {
            //If there is an error, alert the user about it.
            alert("No results found.");
        }
    };

    //Make the geocode request.
    searchManager.geocode(searchRequest);
}
// Handle a map click event.
function mapClicked(e) {
    //Create a pushpin.
    currentPushpin = new Microsoft.Maps.Pushpin(e.location);

    //Add a click event to the pushpin.
    Microsoft.Maps.Events.addHandler(currentPushpin, 'click', pushpinClicked);

    //Add the pushpin to the map.
    map.entities.push(currentPushpin);

    //Open up an input form here the user can enter in details for pushpin. 
    document.getElementById('inputForm').style.display = '';
}
// Save data from the input form to the pushpin and display it in a list. DB functionality not yet implemented.
function saveData() {
    //Get the data from form and add it to the pushpin
    currentPushpin.metadata = {
        title: document.getElementById('titleTbx').value,
        description: document.getElementById('descriptionTbx').value
    };

    //Optionally save this data somewhere (like a database or local storage).
/*    jQuery.ajax({
        url: 'HomeController/Create',
        type: "POST",
        data: "{'Value' : " + currentPushpin.metadata + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            alert("a");
        },
        failure: function (msg) { alert("Error saving data"); }
    });
*/
    // show the the meta data on screen in a list
    document.getElementById('savedSpots').innerHTML += '<br/>' + currentPushpin.metadata.title + ': ' + currentPushpin.metadata.description;

    //Clear the fields in the form and then hide the form.
    document.getElementById('titleTbx').value = '';
    document.getElementById('descriptionTbx').value = '';
    document.getElementById('inputForm').style.display = 'none';
}
// Handle a pushpin click event to display an infobox.
function pushpinClicked(e) {
    if (e.target.metadata) {
        infobox.setOptions({
            location: e.target.getLocation(),
            title: e.target.metadata.title,
            description: e.target.metadata.description,
            visible: true
        });
    }
}
/*// Include your script to load the Bing Maps control and call the 'GetMap' function.
(async () => {
    let script = document.createElement("script");
    script.setAttribute("src", 'https://www.bing.com/api/maps/mapcontrol?callback=GetMap&key=Amcu1rBRxXcBBsLcKr14p3gb51i8PqlTn16iIjhki_AjKujeZfYtg1KjJTbzJerx');
    document.body.appendChild(script);
})();*/