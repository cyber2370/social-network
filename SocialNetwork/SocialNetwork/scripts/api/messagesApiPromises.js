import {
	getAsync, 
	postAsync,
	putAsync,
	deleteAsync	
} from './fetchRequests';

var baseMessagesUrl = 'messages/';
var baseUsersUrl = 'users/';

export function getUserMessagesByUserId(data) {
	let { id as userId } = data; 
	let url = baseUsersUrl + userId + '/messages/';

	return getAsync(url);
}

export function getUserMessagesByUserId(data) {
	let { id as userId } = data; 
	let url = baseUsersUrl + userId + '/messages/';

	return getAsync(url);
}

export function sendMessage(data) {
	let { message } = data; 
	let url = baseMessagesUrl + '/';

	return postAsync(url);
}

export function deleteMessage(data) {
	let { id as messageId } = data; 
	let url = baseMessagesUrl + messageId + '/';

	return deleteAsync(url);
}