
let timeout1,
	timeout2;
const onSubmit = (e, setState) => {
	e.preventDefault();

	const target = e.currentTarget;

	setState((state) => ({ 
		...state, 
		load: true,
	}));
	clearTimeout(timeout1);
	timeout1 = setTimeout(() => {
		const elements = target.elements;

		const card = elements.card.value;
		// const promocode = elements.promocode.value;

		if (card >= 1) {
			clearTimeout(timeout2);
			timeout2 = setTimeout(() => {
				setState(() => ({
					load: false,
					ready: true,
				}));
			}, 800);
		}
	}, 0);
};

export default onSubmit;
