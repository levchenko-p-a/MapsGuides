
const one = (state = null, action) => {
	return action.type === 'one'
		? action.payload()
		: state;
};

export default one;
