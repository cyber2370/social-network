import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';

import friends from './friends';
import locations from './locations';
import workplaces from './workplaces';
import messages from './messages';
import userWorkplaces from './userWorkplaces';

const rootReducer = combineReducers({
	friends,
	locations,
	workplaces,
	messages,
	userWorkplaces,
	routing: routerReducer
});

export default rootReducer;