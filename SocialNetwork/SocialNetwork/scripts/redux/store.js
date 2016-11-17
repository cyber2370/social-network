import { createStore, compose, applyMiddleware } from 'redux';
import { syncHistoryWithStore } from 'react-router-redux';
import { browserHistory } from 'react-router';
import middleware from './middlewares/promisesMiddleware.js';
import rootReducer from './reducers/index';  

let createStoreWithMiddleware = applyMiddleware(middleware)(createStore);

const enhansers = compose(
	window.devToolsExtension ? window.devToolsExtension() : f => f
);

const store = createStoreWithMiddleware(rootReducer, enhansers);
export const history = syncHistoryWithStore(browserHistory, store);

export default store;