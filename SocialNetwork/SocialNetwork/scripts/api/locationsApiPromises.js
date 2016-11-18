import {
	getAsync, 
	postAsync,
	putAsync,
	deleteAsync	
} from './fetchRequests';

let baseLocationsUrl = 'locations/';

export function getLocations() { 
	let url = baseLocationsUrl;

	return getAsync(url);
}