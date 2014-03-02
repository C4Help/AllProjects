var ContactUs = function () {
    return {
        //main function to initiate the module
        init: function () {
			/*var map;
			$(document).ready(function(){
			  map = new GMaps({
				div: '#map',
	            lat: 51.074982,
				lng: -114.128517,
			  });
			   var marker = map.addMarker({
		            lat: 51.074982,
					lng: -114.128517,
		            title: 'University of Calgary',
		            infoWindow: {
		                content: "2500 University Dr NW,<br> Calgary, AB T2N 1N4"
		            }
		        });

			   marker.infoWindow.open(map, marker);

               */


            var myLatlng = new google.maps.LatLng(51.074982, -114.128517);
            var mapOptions = {
                zoom: 15,
                center: myLatlng
            }
            var map = new google.maps.Map(document.getElementById('map'), mapOptions);

            var infowindow = new google.maps.InfoWindow({
                content: "2500 University Dr NW,<br> Calgary, AB T2N 1N4"
            });

            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: 'University of Calgary'
			});

            //infowindow.open(map,marker);
        }
    };

}();