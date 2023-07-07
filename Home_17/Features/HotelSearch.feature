Feature: Hotel search

@mytag
Scenario: Search for hotel and check rating
	Given Hotel with name <HotelName>
	* Hotel rating is <HotelRating>
	When User searches the Hotel
	Then the Hotel is on page
	* Rating is equal to given

Examples:
	| HotelName                   | HotelRating |
	| Pension Kern                | 8.2         |
	| Ibis Praha Wenceslas Square | 7.6         |
	| Franz BY ZEITRAUM           | 9.1         |
	| Backpacker Hostel           | 4.7         |
