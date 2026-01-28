import Navbar from "@/components/home/Navbar";
import Hero from "@/components/home/Hero";
import Capabilities from "@/components/home/Capabilities";
import Crews from "@/components/home/Crews";
import Projects from "@/components/home/Projects";
import Process from "@/components/home/Process";
import Stats from "@/components/home/Stats";
import JoinCTA from "@/components/home/JoinCTA";
import Footer from "@/components/home/Footer";

export default function Home() {
  return (
    <div className="relative min-h-screen overflow-hidden">
      <div className="pointer-events-none">
        <div className="nebula nebula--purple -top-40 -left-32 h-80 w-80" />
        <div className="nebula nebula--blue top-40 -right-40 h-96 w-96" />
        <div className="nebula nebula--purple bottom-[-10rem] right-20 h-72 w-72 opacity-60" />
      </div>

      <Navbar />

      <main className="relative z-10 mx-auto flex max-w-6xl flex-col px-4 pb-20 pt-28 sm:px-6 lg:px-8 lg:pt-32">
        <Hero />
        <Capabilities />
        <Crews />
        <Projects />
        <Process />
        <Stats />
        <JoinCTA />
      </main>

      <Footer />
    </div>
  );
}
