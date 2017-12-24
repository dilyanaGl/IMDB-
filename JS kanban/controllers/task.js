const Task = require('../models/Task');

module.exports = {
	index: (req, res) => {

		Task.find({}).filter(status => {
			return status === "Open";
			}).then(openTasks => {
				res.render("task/index", {openTasks : openTasks});
		});

		Task.findBy().then(inProgressTasks => {
        	res.render("task/index", {inProgressTasks: inProgressTasks});
		});

		Task.find({}).filter(status => {
			return status === "Finished";
		}).then(finishedTasks => {
			res.render("tasks/index", {finishedTasks : finishedTasks});
		})

	},
	createGet: (req, res) => {
		res.render("task/create");
	},
	createPost: (req, res) => {
		let task = req.body;

		Task.create(task).then(task => {
			res.redirect('/');
		}).catch(err => {
			task.error = "Cannot create this task.";
			res.render("task/create", task);
		})
	},
	editGet: (req, res) => {
		let id = req.params.id;
		Task.findById(id).then(task => {
			if(task) {
				res.render("task/edit", task);
			} else {
				res.redirect('/');
			}
		}).catch(err => res.redirect("/"));
	},
	editPost: (req, res) => {
		let id = req.params.id;
		let task = req.body;

		Task.findByIdAndUpdate(id, task, {runValidators: true}).then(task => {
			res.redirect("/");
		}).catch(err => {
			task.id = taskId;
			task.error = "Cannot edit this task.";
			return res.render("task/edit", task);
		})
	}
};