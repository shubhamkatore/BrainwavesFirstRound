<template>
  <nav class="navbar" role="navigation" aria-label="main navigation">
    <div class="navbar-brand">
      <a class="navbar-item" href="/">
        <label class="heading" for>Stock Archives</label>
      </a>
      
      <a
        role="button"
        class="navbar-burger burger"
        aria-label="menu"
        aria-expanded="false"
        data-target="navbarBasicExample"
      >
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
      </a>
    </div>

    <div id="navbarBasicExample" class="navbar-menu">
      <div class="navbar-start">
        <a class="navbar-item" href="/">Home</a>
        <a class="navbar-item" href="/viewallstocks">View All Stocks</a>
        <a class="navbar-item" href="http://www.shubhamkatore.com" target="_blank">My Portfolio</a>
        <a
          class="navbar-item"
          href="https://www.linkedin.com/in/shubhamkatore"
          target="_blank"
        >LinkedIn</a>
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  name: "NavBar"
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.heading {
  font-size: 20px;
  font-weight: bold;
}
</style>
