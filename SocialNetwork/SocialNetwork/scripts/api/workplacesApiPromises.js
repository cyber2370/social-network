import {
	getAsync, 
	postAsync,
	putAsync,
	deleteAsync	
} from './fetchRequests';

let baseUsersUrl = 'users/';
let baseWorkplacesUrl = 'workplaces/';

export function getWorkplaces() { 
	let url = baseWorkplacesUrl;

	return getAsync(url);	
}

export function getUsersByWorkplaceId(data) {
	let { workplaceId } = data; 
	let url = baseWorkplacesUrl + workplaceId + '/';

	return getAsync(url);	
}

export function deleteWorkplace(data) {
	let { workplaceId } = data; 
	let url = baseWorkplacesUrl + workplaceId + '/';

	return deleteAsync(url);	
}

export function deleteUserWorkplace(data) {
	let { userId, workplaceId } = data; 
	let url = baseUsersUrl + userId + '/workplaces/' + workplaceId + '/';

	return deleteAsync(url);	
}