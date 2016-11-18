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
	let url = baseProjectsUrl;

	return putAsync(url, user);
}

export function deleteUserByUserId(data) {
	let { id as userId } = data; 
	let url = baseProjectsUrl + userId + '/';

	return deleteAsync(url);
}

// Additional operation 

export function getUserFriendsByUserId(data) {
	let { id as userId } = data; 
	let url = baseProjectsUrl + userId + '/friends/';

	return getAsync(url);
}

export function getFriendRequestsToUserByUserId(data) {
	let { id as userId } = data; 
	let url = baseProjectsUrl + userId + '/recievedFriendsRequests/';

	return getAsync(url);
}

export function getFriendRequestsFromUserByUserId(data) {
	let { id as userId } = data; 
	let url = baseProjectsUrl + userId + '/sendedFriendsRequests/';

	return getAsync(url);
}

export function deleteFriendRelationByUserIds(data) {
	let { firstUserId, secondUserId } = data; 
	let url = baseProjectsUrl + firstUserId + '/friends/' + secondUserId + '/';

	return deleteAsync(url);
}

// User messages operations 

export function getUserMessagesByUserId(data) {
	let { id as userId } = data; 
	let url = baseProjectsUrl + userId + '/messages/';

	return getAsync(url);
}

export function getUserMessagesByUserId(data) {
	let { id as userId } = data; 
	let url = baseProjectsUrl + userId + '/messages/';

	return getAsync(url);
}