
const many = (state = null, action) => {
	return action.type === 'many'
		? action.payload()
		: state;
};

export default many;
