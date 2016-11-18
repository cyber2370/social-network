"use strict";

import React from 'react';
import { render } from 'react-dom';
import { Router, Route, IndexRoute, hashHistory } from 'react-router';
import { Provider } from 'react-redux';
import store, { history } from '../redux/store';

import App from './components/App';

const MainComponent = React.createClass({
    render() {
        return (
            <Provider store={store}>
              <Router history={history}>
                <Route path="/" component={App}>
                    
                </Route>
              </Router>
            </Provider>
        );
    }
});

render(<MainComponent />, document.getElementById('app'));