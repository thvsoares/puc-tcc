let curso = function() {
    let self = this;
    self.courses = ko.observableArray();

    self.getCourses = () =>  {
        self.courses.removeAll();
        $.get('http://localhost:5000/api/curso')
            .done(data => {
                data.forEach(item => {
                    self.courses.push(item);
                });
            });
    }
}

let model = new curso();
ko.applyBindings(model);
model.getCourses();