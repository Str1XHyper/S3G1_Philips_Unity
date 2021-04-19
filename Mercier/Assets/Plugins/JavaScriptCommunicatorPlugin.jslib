mergeInto(LibraryManager.library, {
getQuestions: function () {
      var response;
      const config = {
          method: "get",
          url: "/Question/Planned/" + 1,
        };
        this.$axios(config)
          .then((result) => {
            response = result.data;
            this.loading = false;
          })
          .catch((error) => {
          });
      return response
}
});