import {
	getAsync, 
	postAsync,
	putAsync,
	deleteAsync	
} from './fetchRequests';

let baseFriendsUrl = 'friends/';
let baseUsersUrl = 'users/';

export function getUserFriendsByUserId(data) {
	let { id as userId } = data; 
	let url = baseUsersUrl + userId + '/friends/';

	return getAsync(url);
}

export function getFriendRequestsToUserByUserId(data) {
	let { id as userId } = data; 
	let url = baseUsersUrl + userId + '/recievedFriendsRequests/';

	return getAsync(url);
}

export function getFriendRequestsFromUserByUserId(data) {
	let { id as userId } = data; 
	let url = baseUsersUrl + userId + '/sendedFriendsRequests/';

	return getAsync(url);
}

export function deleteFriendRelationByUserIds(data) {
	let { firstUserId, secondUserId } = data; 
	let url = baseUsersUrl + firstUserId + '/friends/' + secondUserId + '/';

	return deleteAsync(url);
}