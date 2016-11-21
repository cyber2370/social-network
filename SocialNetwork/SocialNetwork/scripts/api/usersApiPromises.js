import {
	getAsync, 
	postAsync,
	putAsync,
	deleteAsync	
} from './fetchRequests';

let baseUsersUrl = 'users/';

export function getUserByEmail(data) {
	let { email } = data; 
	let url = baseUsersUrl + email + '/';

	return getAsync(url);	
}

export function registerUser(data) {
	let { user } = data; 
	let url = baseUsersUrl;

	return postAsync(url, user);
}

export function updateUser(data) {
	let { user } = data; 
	let url = baseUsersUrl;

	return putAsync(url, user);
}

export function deleteUserByUserId(data) {
	let { id as userId } = data; 
	let url = baseUsersUrl + userId + '/';

	return deleteAsync(url);
}