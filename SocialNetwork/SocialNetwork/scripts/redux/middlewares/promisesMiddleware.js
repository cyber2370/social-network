const middleware = store => next => action => {
	if (action.type !== 'PROMISE') {
	  return next(action);
	}

  const [startAction, successAction, failureAction] = action.actions;
  store.dispatch({type: startAction});

  let queryParams = action.queryParams;

  return action.promise(queryParams).then(function(data) {
    
    if (!data) {
      data = queryParams;
    }

    return store.dispatch({
        type: successAction, 
        data: data
      });
    },
    error => store.dispatch({
    	type: failureAction, 
    	error
    })
  );
};

export default middleware;